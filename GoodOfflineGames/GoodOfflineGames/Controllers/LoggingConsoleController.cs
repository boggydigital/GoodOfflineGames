﻿using System;
using GOG.Interfaces;
using System.IO;

namespace GOG.SharedControllers
{
    class LoggingConsoleController : IDisposableConsoleController
    {
        private string logFilename;
        private IConsoleController consoleController;

        private StreamWriter logStreamWriter;

        public LoggingConsoleController(string logFilename, IConsoleController consoleController)
        {
            this.logFilename = logFilename;
            this.consoleController = consoleController;

            logStreamWriter = new StreamWriter(logFilename, true, System.Text.Encoding.UTF8);
            logStreamWriter.AutoFlush = true;
        }

        public string Read()
        {
            return consoleController.Read();
        }

        public string ReadLine()
        {
            return consoleController.ReadLine();
        }

        public string ReadPrivateLine()
        {
            return consoleController.ReadPrivateLine();
        }

        public void Write(string message, ConsoleColor color, params object[] data)
        {
            // even though write was requested, writeline works better in log context
            logStreamWriter.WriteLine(message, data);
            consoleController.Write(message, color, data);
        }

        public void WriteLine(string message, ConsoleColor color, params object[] data)
        {
            logStreamWriter.WriteLine(message, data);
            consoleController.WriteLine(message, color, data);
        }

        public void Dispose()
        {
            if (logStreamWriter != null) logStreamWriter.Dispose();
        }
    }
}
