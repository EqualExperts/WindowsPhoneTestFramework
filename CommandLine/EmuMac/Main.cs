using System;
using WindowsPhoneTestFramework.CommandLine.CommandLineHost;
using WindowsPhoneTestFramework.CommandLine.CommandLineHost.Commands;
using WindowsPhoneTestFramework.Server.WCFHostedAutomationController;

namespace WindowsPhoneTestFramework.CommandLine.EmuMac
{
    class Program : ProgramBase
    {
        public static void Main(string[] args)
        {
            var commandLine = Args.Configuration.Configure<CommandLine>().CreateAndBind(args);
            try
            {
                Console.WriteLine("AutomationHost starting");
                using (var program = new Program(commandLine))
                {
                    Console.WriteLine("To show help, enter 'help'");
                    program.Run();
                }
            }
            catch (QuitNowPleaseException)
            {
                Console.WriteLine("Goodbye");
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Exception seen {0} {1}", exception.GetType().FullName, exception.Message));
            }
        }

        private ServiceHostController _serviceHost;

        public Program(CommandLine commandLine) 
        {
            StartServiceHost(commandLine);
            var commands = new PhoneAutomationCommands()
                               {
                                   ApplicationAutomationController = _serviceHost.AutomationController
                               };
            AddCommands(commands);
        }

        private void StartServiceHost(CommandLine commandLine)
        {
            Console.WriteLine("-> service will listen for connection on " + commandLine.Binding);
            Console.WriteLine("-> service will identify controls using " + commandLine.AutomationIdentification);
            _serviceHost = new ServiceHostController()
                               {
                                   BindingAddress = new Uri(commandLine.Binding),
                                   AutomationIdentification = commandLine.AutomationIdentification
                               };
            _serviceHost.Trace += (sender, args) => Console.WriteLine("-> " + args.Message); 
            _serviceHost.Start();
            Console.WriteLine("-> service started");
            Console.WriteLine();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (_serviceHost != null)
                {
                    _serviceHost.Dispose();
                    _serviceHost = null;
                }
            }
            base.Dispose(isDisposing);
        }
    }

}

