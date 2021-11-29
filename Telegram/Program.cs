using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Helpers.JSON;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram
{
    class Program
    {

        static void Main()
        {
            Dictionary<int, string> days = new(6);
            days.Add(1, "Понедельник");
            days.Add(2, "Вторник");
            days.Add(3, "Среда");
            days.Add(4, "Четверг");
            days.Add(5, "Пятница");
            days.Add(6, "Суббота");

            var botClient = new TelegramBotClient("1837593586:AAElIgx9Anhpm3tz58zjGNlwO0zcsBxTNdY");

            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };
            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            Console.ReadLine();

            Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                return Task.CompletedTask;
            }

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                if (update.Type != UpdateType.Message)
                {
                    if (update.Type == UpdateType.CallbackQuery)
                    {
                        Console.WriteLine($"Received a '{update.CallbackQuery.Data}' message in chat {update.CallbackQuery.Message.Chat.Id} {update.CallbackQuery.Message.Chat.Username}.");
                        string[] array = update.CallbackQuery.Data.Split(":");
                        if (array[0] == "1")
                        {
                            var url = "http://localhost:5000/api/telegram/cities?CountriesID=";
                            var client = new HttpClient();
                            var response = await client.GetAsync(url + array[2], cancellationToken);
                            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                            var cities = JsonConvert.DeserializeObject<IEnumerable<Cities>>(responseContent);
                            var citiesNameString = "";
                            var citiesIdString = "";
                            foreach (Cities i in cities)
                            {
                                citiesNameString += i.Name + ",";
                                citiesIdString += "2:" + array[1] + ":" + i.Id + ",";
                            }
                            var inlineKeyboard = new InlineKeyboardMarkup(GetInlineKeyboard(citiesNameString.Remove(citiesNameString.Length - 1).Split(","), citiesIdString.Remove(citiesIdString.Length - 1).Split(",")));
                            await botClient.EditMessageTextAsync(chatId: update.CallbackQuery.Message.Chat.Id, messageId: Int32.Parse(array[1]), text: "Выбери город", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
                        }
                        else if (array[0] == "2")
                        {
                            var url = "http://localhost:5000/api/telegram/universities?CitiesID=";
                            var client = new HttpClient();
                            var response = await client.GetAsync(url + array[2], cancellationToken);
                            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                            var universities = JsonConvert.DeserializeObject<IEnumerable<Universities>>(responseContent);
                            var universitiesNameString = "";
                            var universitiesIdString = "";
                            foreach (Universities i in universities)
                            {
                                universitiesNameString += i.Name + ",";
                                universitiesIdString += "3:" + array[1] + ":" + i.Id + ",";
                            }
                            var inlineKeyboard = new InlineKeyboardMarkup(GetInlineKeyboard(universitiesNameString.Remove(universitiesNameString.Length - 1).Split(","), universitiesIdString.Remove(universitiesIdString.Length - 1).Split(",")));
                            await botClient.EditMessageTextAsync(chatId: update.CallbackQuery.Message.Chat.Id, messageId: Int32.Parse(array[1]), text: "Выбери университет", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
                        }
                        else if (array[0] == "3")
                        {
                            var url = "http://localhost:5000/api/telegram/faculties?UniversitiesID=";
                            var client = new HttpClient();
                            var response = await client.GetAsync(url + array[2], cancellationToken);
                            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                            var faculties = JsonConvert.DeserializeObject<IEnumerable<Faculties>>(responseContent);
                            var facultiesNameString = "";
                            var facultiesIdString = "";
                            foreach (Faculties i in faculties)
                            {
                                facultiesNameString += i.Name + ",";
                                facultiesIdString += "4:" + array[1] + ":" + i.Id + ",";
                            }
                            var inlineKeyboard = new InlineKeyboardMarkup(GetInlineKeyboard(facultiesNameString.Remove(facultiesNameString.Length - 1).Split(","), facultiesIdString.Remove(facultiesIdString.Length - 1).Split(",")));
                            await botClient.EditMessageTextAsync(chatId: update.CallbackQuery.Message.Chat.Id, messageId: Int32.Parse(array[1]), text: "Выбери факультет", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
                        }
                        else if (array[0] == "4")
                        {
                            var url = "http://localhost:5000/api/telegram/specialties?FacultiesID=";
                            var client = new HttpClient();
                            var response = await client.GetAsync(url + array[2], cancellationToken);
                            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                            var specialities = JsonConvert.DeserializeObject<IEnumerable<Specialties>>(responseContent);
                            var specialitiesNameString = "";
                            var specialitiesIdString = "";
                            foreach (Specialties i in specialities)
                            {
                                specialitiesNameString += i.Name + ",";
                                specialitiesIdString += "5:" + array[1] + ":" + i.Id + ",";
                            }
                            var inlineKeyboard = new InlineKeyboardMarkup(GetInlineKeyboard(specialitiesNameString.Remove(specialitiesNameString.Length - 1).Split(","), specialitiesIdString.Remove(specialitiesIdString.Length - 1).Split(",")));
                            await botClient.EditMessageTextAsync(chatId: update.CallbackQuery.Message.Chat.Id, messageId: Int32.Parse(array[1]), text: "Выбери специальность", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
                        }
                        else if (array[0] == "5")
                        {
                            var url = "http://localhost:5000/api/telegram/timeTables?SpecialtiesID=";
                            var client = new HttpClient();
                            var response = await client.GetAsync(url + array[2], cancellationToken);
                            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                            var timeTables = JsonConvert.DeserializeObject<IEnumerable<TimeTable>>(responseContent);
                            var timeTablesNameString = "";
                            var timeTablesIdString = "";
                            foreach (TimeTable i in timeTables)
                            {
                                timeTablesNameString += i.Group + ",";
                                timeTablesIdString += "6:" + array[1] + ":" + i.Id + ",";
                            }
                            var inlineKeyboard = new InlineKeyboardMarkup(GetInlineKeyboard(timeTablesNameString.Remove(timeTablesNameString.Length - 1).Split(","), timeTablesIdString.Remove(timeTablesIdString.Length - 1).Split(",")));
                            await botClient.EditMessageTextAsync(chatId: update.CallbackQuery.Message.Chat.Id, messageId: Int32.Parse(array[1]), text: "Выбери группу", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
                        }
                        else if (array[0] == "6")
                        {
                            var url = $"http://localhost:5000/api/telegram/users?TimeTablesID={array[2]}&UserID={update.CallbackQuery.Message.Chat.Id}";
                            var client = new HttpClient();
                            await client.GetAsync(url, cancellationToken);
                            await botClient.EditMessageTextAsync(chatId: update.CallbackQuery.Message.Chat.Id, messageId: Int32.Parse(array[1]), text: "Вы успешно добавлены в базу данных!", cancellationToken: cancellationToken);
                        }
                    }
                    return;
                }
                if (update.Message.Type != MessageType.Text)
                    return;

                var chatId = update.Message.Chat.Id;

                Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId} {update.Message.Chat.FirstName}.");

                Message message = update.Message;

                if (message.Text == "/check")
                {
                    var url = "http://localhost:5000/api/telegram/message/?UserID=";
                    var client = new HttpClient();
                    var response = await client.GetAsync(url + message.Chat.Id, cancellationToken);
                    int lol = 0;
                    var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                    if (responseContent != "")
                    {
                        DateTime dayNow = DateTime.Today;
                        var cal = new GregorianCalendar();
                        var weekNumber = cal.GetWeekOfYear(dayNow, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

                        var timeTable = JsonConvert.DeserializeObject<TimeTable>(responseContent);
                        foreach (Week week in timeTable.Weeks)
                        {
                            if (week.Number == weekNumber % 2)
                            {
                                string responseMessage = "*Расписание на неделю:*";
                                await botClient.SendTextMessageAsync(parseMode: ParseMode.Markdown, chatId: chatId, text: responseMessage, replyMarkup: new ReplyKeyboardRemove(), cancellationToken: cancellationToken);
                                foreach (Day day in week.Days)
                                {
                                    responseMessage = "";
                                    responseMessage += "*" + days[day.Number] + "*\n\n";
                                    lol = 0;
                                    foreach (Lesson lesson in day.Lessons)
                                    {
                                        lol++;
                                        responseMessage += "*" + lesson.Number + " пара*\n";
                                        responseMessage += lesson.Name + " - ";
                                        responseMessage += lesson.Teacher + "\nАудитория - ";
                                        responseMessage += lesson.Audience + "\n\n";
                                    }
                                    if (lol != 0)
                                    {
                                        await botClient.SendTextMessageAsync(parseMode: ParseMode.Markdown, chatId: chatId, text: responseMessage, replyMarkup: new ReplyKeyboardRemove(), cancellationToken: cancellationToken);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: chatId, text: "Вашего расписания нет в базе данных", cancellationToken: cancellationToken);
                    }
                }
                else if (message.Text == "/checktoday")
                {
                    var url = "http://localhost:5000/api/telegram/message/?UserID=";
                    var client = new HttpClient();
                    var response = await client.GetAsync(url + message.Chat.Id, cancellationToken);
                    var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                    if (responseContent != "")
                    {
                        DateTime dayNow = DateTime.Today;
                        var cal = new GregorianCalendar();
                        var weekNumber = cal.GetWeekOfYear(dayNow, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

                        var timeTable = JsonConvert.DeserializeObject<TimeTable>(responseContent);
                        int c = 0;
                        foreach (Week week in timeTable.Weeks)
                        {
                            if (week.Number == weekNumber % 2)
                            {
                                foreach (Day day in week.Days)
                                {
                                    if (day.Number == (int)dayNow.DayOfWeek)
                                    {
                                        string responseMessage = "*Расписание на сегодня:\n\n*";
                                        foreach (Lesson lesson in day.Lessons)
                                        {

                                            responseMessage += "*" + lesson.Number + " пара*\n";
                                            responseMessage += lesson.Name + " - ";
                                            responseMessage += lesson.Teacher + "\nАудитория - ";
                                            responseMessage += lesson.Audience + "\n\n";
                                        }

                                        c = 1;
                                        await botClient.SendTextMessageAsync(parseMode: ParseMode.Markdown, chatId: chatId, text: responseMessage, replyMarkup: new ReplyKeyboardRemove(), cancellationToken: cancellationToken);
                                    }
                                }
                            }
                        }
                        if (c == 0)
                        {
                            await botClient.SendTextMessageAsync(chatId: chatId, text: "Сегодня нет пар!", cancellationToken: cancellationToken);
                        }
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: chatId, text: "Вашего расписания нет в базе данных", cancellationToken: cancellationToken);
                    }
                }
                else if (message.Text == "/checktomorrow")
                {
                    var url = "http://localhost:5000/api/telegram/message/?UserID=";
                    var client = new HttpClient();
                    var response = await client.GetAsync(url + message.Chat.Id, cancellationToken);
                    var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                    if (responseContent != "")
                    {
                        DateTime dayNow = DateTime.Today.AddDays(1);
                        var cal = new GregorianCalendar();
                        var weekNumber = cal.GetWeekOfYear(dayNow, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

                        var timeTable = JsonConvert.DeserializeObject<TimeTable>(responseContent); 
                        int c = 0;
                        foreach (Week week in timeTable.Weeks)
                        {
                            if (week.Number == weekNumber % 2)
                            {
                                foreach (Day day in week.Days)
                                {
                                    if (day.Number == (int)dayNow.DayOfWeek)
                                    {
                                        string responseMessage = "*Расписание на завтра:*\n\n";
                                        foreach (Lesson lesson in day.Lessons)
                                        {

                                            responseMessage += "*" + lesson.Number + " пара*\n";
                                            responseMessage += lesson.Name + " - ";
                                            responseMessage += lesson.Teacher + "\nАудитория - ";
                                            responseMessage += lesson.Audience + "\n\n";
                                        }

                                        c = 1;
                                        await botClient.SendTextMessageAsync(parseMode: ParseMode.Markdown, chatId: chatId, text: responseMessage, replyMarkup: new ReplyKeyboardRemove(), cancellationToken: cancellationToken);
                                    }
                                }
                            }
                        }
                        if (c == 0)
                        {
                            await botClient.SendTextMessageAsync(chatId: chatId, text: "Завтра нет пар!", cancellationToken: cancellationToken);
                        }
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: chatId, text: "Вашего расписания нет в базе данных", cancellationToken: cancellationToken);
                    }
                }
                else if (message.Text == "/setgroup" || message.Text == "/start")
                {
                    var url = "http://localhost:5000/api/telegram/countries";
                    var client = new HttpClient();
                    var response = await client.GetAsync(url, cancellationToken);
                    var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
                    var countries = JsonConvert.DeserializeObject<IEnumerable<Countries>>(responseContent);
                    var countriesNameString = "";
                    var countriesIdString = "";
                    Message messageKeyboard = await botClient.SendTextMessageAsync(chatId: chatId, text: "Выбери страну", cancellationToken: cancellationToken);
                    foreach (Countries i in countries)
                    {
                        countriesNameString += i.Name + ",";
                        countriesIdString += "1:" + messageKeyboard.MessageId + ":" + i.Id + ",";
                    }
                    var inlineKeyboard = new InlineKeyboardMarkup(GetInlineKeyboard(countriesNameString.Remove(countriesNameString.Length - 1).Split(","), countriesIdString.Remove(countriesIdString.Length - 1).Split(",")));
                    await botClient.EditMessageTextAsync(chatId: messageKeyboard.Chat.Id, messageId: messageKeyboard.MessageId, text: "Выбери страну", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
                }
                else
                {
                    await botClient.SendTextMessageAsync(parseMode: ParseMode.Markdown, chatId: chatId, text: "Используй команды из меню", replyMarkup: new ReplyKeyboardRemove(), cancellationToken: cancellationToken);
                }
            }
        }
        private static InlineKeyboardButton[][] GetInlineKeyboard(string[] nameArray, string[] idArray)
        {
            var keyboardInline = new InlineKeyboardButton[nameArray.Length][];
            for (var i = 0; i < nameArray.Length; i++)
            {
                keyboardInline[i] = new InlineKeyboardButton[1];
                keyboardInline[i][0] = InlineKeyboardButton.WithCallbackData(text: nameArray[i], callbackData: idArray[i]);
            }
            return keyboardInline;
        }
    }
}