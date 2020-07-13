namespace population
{
    public class PopulationFormatter
    {
        public static string FormatPopulation(int population)
        {
            if (population == 0)
                return "(Unknown)"
            int popRounded = RoundPopulation4(population);
            return $"{popRounded:### ### ### ###}".Trim();
        }

        // ..more needed here





    }
}