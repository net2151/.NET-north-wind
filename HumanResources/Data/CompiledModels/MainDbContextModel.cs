﻿// <auto-generated />
using HumanResources.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace HumanResources
{
    [DbContext(typeof(MainDbContext))]
    public partial class MainDbContextModel : RuntimeModel
    {
        static MainDbContextModel()
        {
            var model = new MainDbContextModel();
            model.Initialize();
            model.Customize();
            _instance = model;
        }

        private static MainDbContextModel _instance;
        public static IModel Instance => _instance;

        partial void Initialize();

        partial void Customize();
    }
}
