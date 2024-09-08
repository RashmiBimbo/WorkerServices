﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SqlIntegrationUI;

#nullable disable

namespace SqlIntegrationUI.Migrations
{
    [DbContext(typeof(ErpSqlDbContext))]
    [Migration("20240906194314_UpdateTbls")]
    partial class UpdateTbls
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SqlIntegrationUI.Models.DBServiceDetail", b =>
                {
                    b.Property<long>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RecId"));

                    b.Property<bool>("Altered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Columns")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Enable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastRun")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasMaxLength(255)
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextRun")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Period")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(30);

                    b.Property<string>("QueryString")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("cross-company=true");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValue("Running");

                    b.Property<string>("Table")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TimeTaken")
                        .HasColumnType("int");

                    b.Property<long?>("TotalRecordsAdded")
                        .HasColumnType("bigint");

                    b.Property<long?>("TotalRecordsTracked")
                        .HasColumnType("bigint");

                    b.Property<long?>("TotalRecordsUpdated")
                        .HasColumnType("bigint");

                    b.HasKey("RecId");

                    b.ToTable("DBServiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
