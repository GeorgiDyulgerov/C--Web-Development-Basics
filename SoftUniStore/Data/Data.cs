namespace SoftUniStore.Data
{
    public class Data
    {
        private static SoftUniContext context;

        public static SoftUniContext Context => context ?? (context = new SoftUniContext());
    }
}
