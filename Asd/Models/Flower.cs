using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Asd.Models;

public class Flower
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Height { get; set; }
    public string Image { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double Price { get; set; }
    public int Width { get; set; }
    public string Compound { get; set; } = default!;
}

public class CreationFlower
{
	[Required]
	[Range(1, int.MaxValue)]
	public int Width { get; set; }

	[Required]
	[MinLength(3)]
	public string Compound { get; set; }

	[MinLength(3)]
	[Required]
	public string Name { get; set; } = default!;

	[Required]
	[Range(1, int.MaxValue)]
	public int Height { get; set; }

	[Required]
	[MinLength(10)]
	public string Description { get; set; } = default!;

	[Required]
	[Range(1, int.MaxValue)]
	public double Price { get; set; }

	[Required] public IFormFile Image { get; set; }
}