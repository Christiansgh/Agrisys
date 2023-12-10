namespace Agrisys.Models
{
    public static class Repository
    {
    
        
            private static List<DropOption> dropOptions = new();
            public static IEnumerable<DropOption> DropOption => dropOptions;
            public static void AddResponse(DropOption dropOption)
            {
            Console.WriteLine(dropOption);
            dropOptions.Add(dropOption);
            }
        
    }
}
