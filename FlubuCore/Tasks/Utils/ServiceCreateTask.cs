﻿namespace FlubuCore.Tasks.Utils
{
    /// <summary>
    /// Creates a service entry in the registry and Service Database.
    /// </summary>
    public class ServiceCreateTask : ServiceControlTaskBase<ServiceCreateTask>
    {
        public ServiceCreateTask(string serviceName, string pathToService) : base(StandardServiceControlCommands.Create.ToString(), serviceName)
        {
            Arguments.Add($"binPath={pathToService}");
        }

        /// <summary>
        /// Set start mode of the service.
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public ServiceCreateTask StartMode(ServiceControlStartMode start)
        {
            string arg;
            switch (start)
            {
                case ServiceControlStartMode.DelayedAuto:
                {
                    arg = "Delayed-Auto";
                    break;
                }
                default:
                {
                    arg = start.ToString();
                    break;
                }
            }

            Arguments.Add($"start={arg}");
            return this;
        }
    }
}
