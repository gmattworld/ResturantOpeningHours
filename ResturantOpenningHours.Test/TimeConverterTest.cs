using System.Collections.Generic;
using FluentAssertions;
using ResturantOpenningHours.API.Logic;
using ResturantOpenningHours.Model.ApplicationModel;
using Xunit;

namespace ResturantOpenningHours.Test
{
    public class TimeConverterTest
    {
        [Fact]
        public void RestaurantOpenAndClose_SameDay()
        {
            OpenningAndClosingHoursResponse t = new TimeConverter().Converter(BuildRequest_SameDay());

            t.Monday.Should().Contain("Monday: 10:00 AM - 5:00 PM");
            t.Tuesday.Should().Contain("Tuesday: 10:00 AM - 5:00 PM");
            t.Wednesday.Should().Contain("Wednesday: 10:00 AM - 5:00 PM");
            t.Thursday.Should().Contain("Thursday: 10:00 AM - 5:00 PM");
            t.Friday.Should().Contain("Friday: 10:00 AM - 5:00 PM");
            t.Saturday.Should().Contain("Saturday: 10:00 AM - 5:00 PM");
            t.Sunday.Should().Contain("Sunday: 10:00 AM - 5:00 PM");
        }

        [Fact]
        public void RestaurantOpenAndClose_DifferentDay()
        {
            OpenningAndClosingHoursResponse t = new TimeConverter().Converter(BuildRequest_DifferentDay());

            t.Monday.Should().StartWith("Sunday: 5:00 PM - Monday: 10:00 AM");
            t.Tuesday.Should().Contain("Monday: 5:00 PM - Tuesday: 10:00 AM");
            t.Wednesday.Should().Contain("Tuesday: 5:00 PM - Wednesday: 10:00 AM");
            t.Thursday.Should().Contain("Wednesday: 5:00 PM - Thursday: 10:00 AM");
            t.Friday.Should().Contain("Thursday: 5:00 PM - Friday: 10:00 AM");
            t.Saturday.Should().Contain("Friday: 5:00 PM - Saturday: 10:00 AM");
            t.Sunday.Should().Contain("Saturday: 5:00 PM - Sunday: 10:00 AM");
        }

        [Fact]
        public void RestaurantOpenAndClose_MulipleOpenTimePerDay()
        {
            OpenningAndClosingHoursResponse t = new TimeConverter().Converter(BuildRequest_MultipleOpenTime());

            t.Monday.Should().Contain("10:00 AM - 1:00 PM");
            t.Tuesday.Should().Contain("10:00 AM - 1:00 PM");
            t.Wednesday.Should().Contain("10:00 AM - 1:00 PM");
            t.Thursday.Should().Contain("10:00 AM - 1:00 PM");
            t.Friday.Should().Contain("10:00 AM - 1:00 PM");
            t.Saturday.Should().Contain("10:00 AM - 1:00 PM");
            t.Sunday.Should().Contain("10:00 AM - 1:00 PM");
        }


        #region Test Setup
        private OpenningAndClosingHoursReqest BuildRequest_SameDay()
        {
            return new OpenningAndClosingHoursReqest()
            {
                Sunday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Monday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Tuesday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Wednesday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Thursday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Friday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Saturday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                }
            };
        }

        private OpenningAndClosingHoursReqest BuildRequest_DifferentDay()
        {
            return new OpenningAndClosingHoursReqest()
            {
                Sunday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Monday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Tuesday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Wednesday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Thursday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Friday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Saturday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619283600, // 5:00 PM
                    }
                }
            };
        }

        private OpenningAndClosingHoursReqest BuildRequest_MultipleOpenTime()
        {
            return new OpenningAndClosingHoursReqest()
            {
                Sunday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619269200, //1:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619272800, //2:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Monday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619269200, //1:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619272800, //2:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Tuesday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619269200, //1:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619272800, //2:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Wednesday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619269200, //1:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619272800, //2:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Thursday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619269200, //1:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619272800, //2:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Friday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619269200, //1:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619272800, //2:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                },
                Saturday = new List<OpenHourModel> {
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619258400, // 10:00 AM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619269200, //1:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "open",
                        Value = 1619272800, //2:00 PM
                    },
                    new OpenHourModel
                    {
                        Type = "close",
                        Value = 1619283600, // 5:00 PM
                    }
                }
            };
        }

        #endregion
    }
}
