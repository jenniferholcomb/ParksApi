using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
  public class ParksApiContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }

    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>().HasData(
        new Park { ParkId = 1, 
                   Name = "Cape Lookout State Park",
                   Location = "Tillamook County",
                   State = "Oregon",
                   Type = "coast",
                   Terrain = "coastal, old-growth forest, high cliffs, rugged",
                   Features = "beach, hiking, lookouts, camping"
                 },
        new Park { ParkId = 2, 
                   Name = "Tyron Creek State Natural Area",
                   Location = "Portland",
                   State = "Oregon",
                   Type = "city",
                   Terrain = "woodsy ravine, creek" 
                   Features = "hiking, springtime wildflowers, wheelchair access loops"
                  },
        new Park { ParkId = 3, 
                   Name = "Mt St Helens National Volcanic Monument",
                   Location = "Gifford Pinchot National Forest",
                   State = "Washington",
                   Type = "mountain",
                   Terrain = "volcanic, old-growth forest, lakes, waterfalls in canyon" 
                   Features = "hiking, wheelchair access loops, viewpoints"
                  },
        new Park { ParkId = 4, 
                   Name = "Beacon Rock State Park",
                   Location = "Columbia Gorge",
                   State = "Washington",
                   Type = "gorge",
                   Terrain = "rocky near clifftops, forest, river" 
                   Features = "overlooks of Columbia River, spring wildflowers, wheelchair accessible loop" 
                  },
        new Park { ParkId = 5, 
                   Name = "Smith Rock State Park",
                   Location = "Terrebone",
                   State = "Oregon",
                   Type = "high desert, tugg and basalt cliffs",
                   Terrain = "steep cliffs, river",
                   Features = "rock climbing, camping, hiking"
                  }                                                     
      )
    }
  }
}

