using AppStudio.Uwp.Commands;
using MicrosoftHel10World.DataProviders.Hel10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Appointments;
using Windows.UI.Xaml;

namespace MicrosoftHel10World.Commands
{
    class Hel10Commands
    {
        public static ICommand AddToCalendar
        {
            get
            {
                return new RelayCommand<Hel10Schema>(async p =>
                {
                    DateTime localTime = DateTime.SpecifyKind(p.StartDateTime, DateTimeKind.Local);
                    var a = new Appointment
                    {
                        Subject = $"Hel10 World sesión: {p.Title}",
                        StartTime = new DateTimeOffset(localTime),
                        Duration = p.EndDateTime - p.StartDateTime
                    };

                    await AppointmentManager.ShowAddAppointmentAsync(a, RectHelper.Empty);
                });
            }
        }
    }
}
