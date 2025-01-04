﻿using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection.Emit;

namespace CourseManagementSystemMicroservice.Catalog.Api.Repositories;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToCollection("courses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Name).HasElementName("name").HasMaxLength(100);
        builder.Property(x => x.Description).HasElementName("description").HasMaxLength(1000);
        builder.Property(x => x.Created).HasElementName("created");
        builder.Property(x => x.UserId).HasElementName("userId");
        builder.Property(x => x.CategoryId).HasElementName("categoryId");
        builder.Property(x => x.Price).HasBsonRepresentation(BsonType.Decimal128).HasElementName("price");
        builder.Property(x => x.Picture).HasElementName("picture");
        builder.Ignore(x => x.Category);

        builder.OwnsOne(x => x.Feature, feature =>
        {
            feature.HasElementName("feature");
            feature.Property(x => x.Duration).HasElementName("duration");
            feature.Property(x => x.Rating).HasElementName("rating");
            feature.Property(x => x.EducatorFullName).HasElementName("educatorFullName");

        });
    }
}
