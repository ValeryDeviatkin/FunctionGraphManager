using System;

namespace Database.Dto
{
    internal class GraphDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public GraphPointDto[] Points { get; set; }
    }
}