// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Core.AlarmFactory.Create(new Core.Alarm(DateTime.Now, Core.AlarmState.On));

