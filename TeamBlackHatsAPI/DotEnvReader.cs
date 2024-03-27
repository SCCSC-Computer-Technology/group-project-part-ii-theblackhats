namespace TeamBlackHatsAPI
{
    public class DotEnvReader
    {
        private string location = "";

        /// <summary>
        /// Sets the environment file to ".env"
        /// </summary>
        public DotEnvReader()
        {
            this.location = ".env";
        }

        /// <summary>
        /// Sets the environment to the location specified
        /// </summary>
        /// <param name="location"></param>
        public DotEnvReader(string location)
        {
            this.location = location;
        }

        /// <summary>
        /// Loads a .env file and creates environment variables
        /// </summary>
        /// <returns>Whether the environment variables were successfully created</returns>
        public bool LoadEnv()
        {
            if (!File.Exists(location)) { return false; }

            string[] lines = File.ReadAllLines(location);

            List<string[]> environmentVariables = new List<string[]>();
            foreach (string line in lines)
            {
                string[] splitLine = line.Split('=');
                if (splitLine.Length != 2) { return false; }

                environmentVariables.Add(splitLine);
            }

            foreach (string[] environmentVariable in environmentVariables)
            {
                Environment.SetEnvironmentVariable(environmentVariable[0], environmentVariable[1]);
            }
            return true;

        }
    }
}
