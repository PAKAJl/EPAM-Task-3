using System;
using System.Collections.Generic;
using Task3.AutomaticStation;
using Task3.AutomaticStation.Interfaces;
using Task3.BillingSystem;
using Task3.BillingSystem.Interfaces;
using Task3.BillingSystem.Models;
using Task3.Logger;
using Task3.Logger.Interfaces;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ITariff tariff = new Tariff();
            IOperator teleOperator = new Operator();
            IStation station = new Station();

            ILogger logger = new ConsoleLogger();

            teleOperator.AddStation(station);
            
            IAbonent abonent1 = new Abonent(tariff, "+375446465765", new Terminal());
            IAbonent abonent2 = new Abonent(tariff, "+375296465765", new Terminal());
            IAbonent abonent3 = new Abonent(tariff, "+375336465765", new Terminal());

            teleOperator.AddAbonent(abonent1, station);
            teleOperator.AddAbonent(abonent2, station);
            teleOperator.AddAbonent(abonent3, station);

            abonent1.TopUpBalance(40);
            abonent2.TopUpBalance(10);

            abonent1.Terminal.Connect();
            abonent2.Terminal.Connect();

            foreach (var port in station.GetPortStatusList())
            {
                logger.Log(port);
            }
           
            abonent1.Terminal.Call("+375296465765");

            logger.Log("");

            abonent2.Terminal.Call("+375336465765");
            logger.Log("");
            abonent1.Terminal.Call("+375296465765");
            logger.Log("");
            abonent1.Terminal.Call("+375296465765");
            logger.Log("");
            foreach (var port in station.GetPortStatusList())
            {
                logger.Log(port);
            }

            ICollection<Call> calls = abonent1.GetCallReport().Filter(FilterParameters.ABONENT, "+375296465765");

            foreach (var call in calls)
            {
                call.Write(logger);
            }

            Console.ReadKey();
        }
    }
}
