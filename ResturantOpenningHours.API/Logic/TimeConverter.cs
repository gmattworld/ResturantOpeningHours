using ResturantOpenningHours.Model.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantOpenningHours.API.Logic
{
    public class TimeConverter
    {
        /// <summary>  
        /// this action get the UTC time from the unix time 
        /// </summary>  
        public static string UnixTimeStampToShortTimeString(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToShortTimeString();
        }
        /// <summary>  
        /// this handles the converstion for all the model
        /// </summary> 
        public OpenningAndClosingHoursResponse Converter(OpenningAndClosingHoursReqest list)
        {

            return new OpenningAndClosingHoursResponse
            {
                Sunday = string.Format("{0}", PrintTime(TimeSorteer(list.Sunday, list.Saturday, list.Monday, "Saturday", "Sunday", "Monday"))),
                Monday = string.Format("{0}", PrintTime(TimeSorteer(list.Monday, list.Sunday, list.Tuesday, "Sunday", "Monday", "Tuesday"))),
                Tuesday = string.Format("{0}", PrintTime(TimeSorteer(list.Tuesday, list.Monday, list.Wednesday, "Monday", "Tuesday", "Wednesday"))),
                Wednesday = string.Format("{0}", PrintTime(TimeSorteer(list.Wednesday, list.Tuesday, list.Thursday, "Tuesday", "Wednesday", "Thursday"))),
                Thursday = string.Format("{0}", PrintTime(TimeSorteer(list.Thursday, list.Wednesday, list.Friday, "Wednesday", "Thursday", "Friday"))),
                Friday = string.Format("{0}", PrintTime(TimeSorteer(list.Friday, list.Thursday, list.Saturday, "Thursday", "Friday", "Saturday"))),
                Saturday = string.Format("{0}", PrintTime(TimeSorteer(list.Saturday, list.Friday, list.Sunday, "Friday", "Saturday", "Sunday"))),

            };


        }

        /// <summary>  
        /// get the time readable timestamp
        /// </summary> 

        public List<Time> TimeSorteer(List<OpenHourModel> openHourModel, List<OpenHourModel> previousDay, List<OpenHourModel> nextDay, string previousDayAsWord, string currentDay, string nextDayAsWord)
        {
            var times = new List<Time>();
            if (openHourModel == null) return times;

            var allitems = openHourModel.OrderBy(x => x.Value).ToList();
            //var openhours = openHourModel.OrderBy(x => x.Type).Where(x => x.Type.ToLower() == "open").ToList();
            //var closehours = openHourModel.OrderBy(x => x.Type).Where(x => x.Type.ToLower() == "close").ToList();

            if (allitems.Count < 1) return times;

            if ((previousDay != null) && (previousDay.Any()))
            {
                previousDay = previousDay.OrderBy(x => x.Value).ToList();

                // Check if the restaurant open since previous day
                // Check if the last element in previous is open and the first element in allitems day is close
                if (allitems.FirstOrDefault().Type.ToLower() == "close" && (previousDay.Count > 0 && previousDay.LastOrDefault().Type.ToLower() == "open"))
                {
                    var time = new Time
                    {
                        OpenTime = $"{previousDayAsWord}: {UnixTimeStampToShortTimeString(previousDay.LastOrDefault().Value)}",
                        CloseTime = $"{currentDay}: {UnixTimeStampToShortTimeString(allitems.FirstOrDefault().Value)}"
                    };
                    times.Add(time);
                    allitems.RemoveAt(0);
                }
            }

            // Get item count
            int itemCount = allitems.LastOrDefault().Value.Equals("open") ? allitems.Count - 1 : allitems.Count;
            if (itemCount >= 2)
            {
                // This is a bubble sort algorithm implementation with a worse case of O(n**2)
                //foreach (var openitemhour in openhours)
                //{
                //    foreach (var closeitemhour in closehours)
                //    {
                //        if (openitemhour.Value < closeitemhour.Value)
                //        {
                //            var time = new Time
                //            {
                //                OpenTime = UnixTimeStampToShortTimeString(openitemhour.Value),
                //                CloseTime = UnixTimeStampToShortTimeString(closeitemhour.Value)
                //            };
                //            times.Add(time);
                //            closehours.Remove(closeitemhour);
                //            break;
                //        }
                //    }
                //}


                // Since we are considering a restaurant, all things being equal,
                // to every open, there should be a close. Since `allitems` as been sorted in order,
                // pairing allitems in 2s should solve a scenerio where the open time is the same day
                for (int i = 0; i < itemCount; i = i + 2)
                {
                    var time = new Time
                    {
                        OpenTime = $"{currentDay}: {UnixTimeStampToShortTimeString(allitems[i].Value)}",
                        CloseTime = UnixTimeStampToShortTimeString(allitems[i + 1].Value)
                    };
                    times.Add(time);
                }
            }

            // To capture cases for next close day extending till following day
            if ((nextDay != null) && (nextDay.Any()))
            {
                nextDay = nextDay.OrderBy(x => x.Value).ToList();
                if (allitems.LastOrDefault().Type.ToLower() == "open" && (nextDay.Count > 0 && nextDay.FirstOrDefault().Type.ToLower() == "close"))
                {
                    var time = new Time
                    {
                        OpenTime = $"{currentDay}: {UnixTimeStampToShortTimeString(allitems.LastOrDefault().Value)}",
                        CloseTime = $"{nextDayAsWord}: {UnixTimeStampToShortTimeString(nextDay.FirstOrDefault().Value)}"
                    };
                    times.Add(time);
                }
            }

            return times;
        }


        /// <summary>  
        /// Prints the time stamp for easy read.
        /// </summary> 
        public string PrintTime(List<Time> timer)
        {
            
            if (timer == null || timer.Count < 1) return "Closed";
            if (timer.Count == 1) return string.Format("{0} - {1}", timer.First().OpenTime, timer.First().CloseTime);
            else
            {
                var value = "";
                foreach (var item in timer)
                {
                    // TO allow priniting multiple opening and closing time
                    value += string.Format("{0} - {1}, ", item.OpenTime, item.CloseTime);
                }

                // To remove trailing space
                return value.TrimEnd();
            }
        }
    }

    public class Time
    {
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
    }
}
