using System;
using System.Collections.Generic;
using System.Linq;

namespace Food.Orders.Application.Domain.Persistence.Projections
{
    public static class Customers
    {
        public static Customer GetById(Guid id)
        {
            return new List<Customer>
                {
                    new(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Allegra Morton"),
                    new(Guid.Parse("f75235d1-dd42-4cd0-90e4-bac2a86283b1"), "Guilherme Charlin"),
                    new(Guid.Parse("78b5dcc4-6d85-4906-a918-864ffd1575a8"), "Keegan Garrett"),
                    new(Guid.Parse("9fa284ed-c654-40c2-8c8c-c81336a153f4"), "Hall Wilson")
                }
                .SingleOrDefault(x => x.Id == id);
        }
    }

    public static class Merchants
    {
        public static Merchant GetById(Guid id)
        {
            return new List<Merchant>
                {
                    new(Guid.Parse("8b4f15cf-1136-49d6-bee6-4e849b7bf6f8"), "Outback Steak"),
                    new(Guid.Parse("6d9d5ee8-773d-442c-9ca2-6d56c7b6eac5"), "Mc Donald´s"),
                    new(Guid.Parse("e955a99e-799a-4716-9ff9-3b4cf490cfbf"), "Bar do Zé")
                }
                .SingleOrDefault(x => x.Id == id);
        }
    }

    public static class Products
    {
        public static Product GetById(Guid id)
        {
            return new List<Product>
                {
                    new(Guid.Parse("1a0b8120-81ee-4321-bbcd-60c974c73289"), "Mc Lanche Feliz", 30),
                    new(Guid.Parse("75d19edd-f842-4fa1-bea5-665a114118a2"), "Jr Ribs", 68),
                        new(Guid.Parse("54b81540-9487-412e-aa08-58022a238ca5"), "El Ranchito", 25),
                    new(Guid.Parse("b8a00987-4472-49b4-a3af-d77df31a857e"), "Pizza a moda da casa", 4)
                }
                .SingleOrDefault(x => x.Id == id);
        }
    }
}