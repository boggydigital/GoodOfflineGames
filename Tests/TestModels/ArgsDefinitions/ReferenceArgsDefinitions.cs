using Models.ArgsDefinitions;

namespace Tests.TestModels.ArgsDefinitions
{
    public static class ReferenceArgsDefinition
    {
        public static ArgsDefinition ArgsDefinition { get; set; } = new ArgsDefinition
        {
            DefaultArgs = "help",
            Methods = new[]
            {
                new Method
                {
                    Title = "authorize",
                    Order = 10,
                    Collections = new string[0],
                    Parameters = new[] {"username", "password"}
                },
                new Method
                {
                    Title = "download",
                    Order = 40,
                    Collections = new[] {"productimages", "accountproductimages", "screenshots", "productfiles"},
                    Parameters = new[] {"id", "os", "lang"}
                },
                new Method
                {
                    Title = "prepare",
                    Order = 30,
                    Collections = new[] {"productimages", "accountproductimages", "screenshots", "productfiles"},
                    Parameters = new[] {"id", "os", "lang"}
                },
                new Method
                {
                    Title = "update",
                    Order = 20,
                    Collections = new[]
                    {
                        "products", "accountproducts", "apiproducts", "gamedetails", "updated",
                        "wishlisted", "screenshots"
                    },
                    Parameters = new[] {"id"}
                }
            },
            MethodsSets = new[]
            {
                new MethodsSet
                {
                    Title = "sync",
                    Methods = new[] {"update", "prepare", "download"}
                }
            },
            Collections = new[]
            {
                new Collection {Title = "products"},
                new Collection {Title = "accountproducts"},
                new Collection {Title = "apiproducts"},
                new Collection {Title = "gamedetails"},
                new Collection {Title = "updated"},
                new Collection {Title = "wishlisted"},
                new Collection {Title = "screenshots"},
                new Collection {Title = "accountproductimages"},
                new Collection {Title = "productimages"},
                new Collection {Title = "productfiles"}
            },
            Parameters = new[]
            {
                new Parameter {Title = "username"},
                new Parameter {Title = "password"},
                new Parameter {Title = "id"},
                new Parameter {Title = "os", Values = new[] {"windows", "osx", "linux"}},
                new Parameter {Title = "lang", Values = new[] {"en"}}
            },
            Dependencies = new[]
            {
                new Dependency
                {
                    Method = "update",
                    Collections = new[]
                        {"accountproducts", "apiproducts", "gamedetails", "updated", "wishlisted"},
                    Requires = new[]
                    {
                        new Dependency
                        {
                            Method = "authorize",
                            Collections = new string[0]
                        }
                    }
                },
                new Dependency
                {
                    Method = "download",
                    Collections = new[] {"productfiles"},
                    Requires = new[]
                    {
                        new Dependency
                        {
                            Method = "authorize",
                            Collections = new string[0]
                        },
                        new Dependency
                        {
                            Method = "prepare",
                            Collections = new[] {"productfiles"}
                        },
                        new Dependency
                        {
                            Method = "update",
                            Collections = new[] {"gamedetails"}
                        }
                    }
                }
            }
        };
    }
}