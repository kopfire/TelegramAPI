using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TelegramAPI.Models;
using TelegramAPI.Repository;
using TelegramAPI.Repository.Impl;
using testAPI.DTO;
using testAPI.DTO.ASU;

namespace TelegramAPI.Helpers.Parser
{
    public class ASU
    {
        private static readonly IFacultiesRepository _facultiesService = new FacultiesRepository();
        private static readonly ISpecialtiesRepository _specialtiesService = new SpecialtiesRepository();
        private static readonly ITimeTableRepository _timeTableService = new TimeTablesRepository();

        public static void Pars()
        {
            Dictionary<string, int> days = new(6)
            {
                { "ПН", 1 },
                { "ВТ", 2 },
                { "СР", 3 },
                { "ЧТ", 4 },
                { "ПТ", 5 },
                { "СБ", 6 }
            };
            var url = "http://m.raspisanie.asu.edu.ru//student/faculty";
            HttpClient httpClient = new();
            var result = httpClient.PostAsync(url, new StringContent("")).Result;
            var resultContent = result.Content.ReadAsStringAsync().Result;
            var timeTable = JsonSerializer.Deserialize<Facul>("{\"q\":" + resultContent + "}");
            foreach (MyItem i in timeTable.q)
            {
                var idF = _facultiesService.CreateOrUpdate(new Faculties { Name = i.name.Replace(",", ""), University = "617477bee3592a8c4fe4458f" }).Result;
                MultipartFormDataContent form = new();
                form.Add(new StringContent(i.id), "id_spec");
                HttpResponseMessage response = httpClient.PostAsync("http://m.raspisanie.asu.edu.ru//student/specialty", form).Result;
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var speciality = JsonSerializer.Deserialize<Facul>("{\"q\":" + responseContent + "}");
                foreach (MyItem j in speciality.q)
                {
                    var spec = j.name[..8] + " " + j.name.Substring(j.name.LastIndexOf("(") + 1, 3);
                    if (j.name.IndexOf("\"") != -1)
                    {
                        spec += " " + j.name[(j.name.IndexOf("\"") + 1)..j.name.LastIndexOf("\"")].Replace(",", "");
                    }

                    var idS = _specialtiesService.CreateOrUpdate(new Specialties { Name = spec, Facylty = idF }).Result;
                    form = new MultipartFormDataContent
                    {
                        { new StringContent(j.id), "val_spec" }
                    };
                    HttpResponseMessage responseKurs = httpClient.PostAsync("http://m.raspisanie.asu.edu.ru//student/kurs", form).Result;
                    var responseContentKurs = responseKurs.Content.ReadAsStringAsync().Result;
                    var kurs = JsonSerializer.Deserialize<Facul>("{\"s\":" + responseContentKurs + "}");
                    foreach (Kurs z in kurs.s)
                    {
                        form = new MultipartFormDataContent
                        {
                            { new StringContent(j.id), "val_spec" },
                            { new StringContent(z.kurs), "kurs" }
                        };
                        HttpResponseMessage responseGroup = httpClient.PostAsync("http://m.raspisanie.asu.edu.ru//student/grup", form).Result;
                        var responseContentGroup = responseGroup.Content.ReadAsStringAsync().Result;
                        if (responseContentGroup.Length > 4)
                        {
                            responseContentGroup = Regex.Replace(responseContentGroup, @"\\u([\da-f]{4})", m => ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString());
                            responseContentGroup = responseContentGroup.Replace("\"", "");
                            responseContentGroup = responseContentGroup[1..^1];
                            var arrGroup = responseContentGroup.Split(",");
                            foreach (string u in arrGroup)
                            {
                                if (arrGroup.Length % 3 != 0 || u.Length == 6)
                                {
                                    var weeks = new List<WeekDTO>();
                                    form = new MultipartFormDataContent();
                                    HttpResponseMessage responseTimeTable = httpClient.PostAsync("http://m.raspisanie.asu.edu.ru/student/" + u, form).Result;
                                    var responseContentTimeTable = responseTimeTable.Content.ReadAsStringAsync().Result;
                                    responseContentTimeTable = Regex.Replace(responseContentTimeTable, @"\\u([\da-f]{4})", m => ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString());
                                    List<string> hrefTags = new();

                                    var parser = new HtmlParser();
                                    var document = parser.ParseDocument(responseContentTimeTable);
                                    var els = document.QuerySelectorAll("div.vot_den");

                                    var dayCh = new List<DayDTO>();
                                    var dayZn = new List<DayDTO>();

                                    foreach (var e in els)
                                    {
                                        var day = days[e.QuerySelectorAll("div.dennedeli")[0].InnerHtml];

                                        var elsDay = e.QuerySelectorAll("div.den-content");

                                        var lesCh = new List<LessonDTO>();
                                        var lesZn = new List<LessonDTO>();

                                        foreach (var ee in elsDay)
                                        {
                                            var para = (ee.QuerySelectorAll("div.npara")[0].InnerHtml)[0] - '0';
                                            var time = ee.QuerySelectorAll("div.time-para")[0].InnerHtml;

                                            var chisl = ee.QuerySelectorAll("div.td_style2_ch")[0];

                                            if (chisl.QuerySelectorAll("span.naz_disc").Length != 0)
                                            {
                                                lesCh.Add(new LessonDTO
                                                {
                                                    Audience = chisl.QuerySelectorAll("span.segueAud").Length != 0
                                                    ? chisl.QuerySelectorAll("span.segueAud")[0].InnerHtml : "",
                                                    Name = chisl.QuerySelectorAll("span.naz_disc")[0].InnerHtml,
                                                    Teacher = chisl.QuerySelectorAll("a.segueTeacher").Length != 0
                                                    ? chisl.QuerySelectorAll("a.segueTeacher")[0].InnerHtml : "",
                                                    Time = time.Replace("<br>", "-"),
                                                    Number = para
                                                });
                                            }

                                            var znamen = ee.QuerySelectorAll("div.td_style2_zn")[0];

                                            if (znamen.QuerySelectorAll("span.naz_disc").Length != 0)
                                            {
                                                lesZn.Add(new LessonDTO
                                                {
                                                    Audience = znamen.QuerySelectorAll("span.segueAud").Length != 0
                                                    ? znamen.QuerySelectorAll("span.segueAud")[0].InnerHtml : "",
                                                    Name = znamen.QuerySelectorAll("span.naz_disc")[0].InnerHtml,
                                                    Teacher = znamen.QuerySelectorAll("a.segueTeacher").Length != 0
                                                    ? znamen.QuerySelectorAll("a.segueTeacher")[0].InnerHtml : "",
                                                    Time = time.Replace("<br>", "-"),
                                                    Number = para
                                                });
                                            }
                                        }

                                        if (lesCh.Count != 0)
                                            dayCh.Add(new DayDTO { Lessons = lesCh, Number = day });
                                        if (lesZn.Count != 0)
                                            dayZn.Add(new DayDTO { Lessons = lesZn, Number = day });
                                    }
                                    weeks.Add(new WeekDTO { Days = dayCh, Number = 1 });
                                    weeks.Add(new WeekDTO { Days = dayZn, Number = 0 });
                                    _timeTableService.CreateOrUpdate(new TimeTable { Speciality = idS, Group = u, Weeks = weeks });
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Обновление выполнено успешно");
        }
    }
}
