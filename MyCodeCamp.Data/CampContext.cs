﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyCodeCamp.Data.Entities;

namespace MyCodeCamp.Data
{
  public class CampContext
  {
    private IConfigurationRoot _config;

    public CampContext(DbContextOptions options, IConfigurationRoot config)
      : base(options)
    {
      _config = config;
    }

    public DbSet<Camp> Camps { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Talk> Talks { get; set; }

  }
}
