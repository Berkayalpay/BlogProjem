using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammersBlog.Data.Migrations
{
    public partial class SeedingArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
      "INSERT INTO [ProgrammersBlog].dbo.Articles (Title,[Content],Note,Thumbnail,[Date],[CreatedDate],CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted,UserId,CategoryId,SeoAuthor,SeoDescription,SeoTags,CommentCount,ViewsCount) " +
      "VALUES ('.NET5 ile Gelen Yenilikler','Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. ...', 'İlk C# Paylaşımı', 'postImages/defaultThumbnail.jpg', GETDATE(), GETDATE(), 'Migration', GETDATE(), 'Migration', 1, 0, 1, 1, 'C# Developer', 'C# 9.0 .NET5', 'C# F# .NET CORE .NET ASP.NET MVC5', 0, 1)");

            migrationBuilder.Sql(
                "INSERT INTO [ProgrammersBlog].dbo.Articles (Title,[Content],Note,Thumbnail,[Date],[CreatedDate],CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted,UserId,CategoryId,SeoAuthor,SeoDescription,SeoTags,CommentCount,ViewsCount) " +
                "VALUES ('C++ ile Algoritma Yapıları','Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. ...', 'İlk C++ Paylaşımı', 'postImages/defaultThumbnail.jpg', GETDATE(), GETDATE(), 'Migration', GETDATE(), 'Migration', 1, 0, 1, 2, 'C++ Developer', 'C++ 99, 11 20, Linked List Veri Yapıları', 'C++ 99, 11 20, Linked List Veri Yapıları', 0, 10)");

            migrationBuilder.Sql(
                "INSERT INTO [ProgrammersBlog].dbo.Articles (Title,[Content],Note,Thumbnail,[Date],[CreatedDate],CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted,UserId,CategoryId,SeoAuthor,SeoDescription,SeoTags,CommentCount,ViewsCount) " +
                "VALUES ('Asenkron JavaScript','Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. ...', 'İlk JavaScript Paylaşımı', 'postImages/defaultThumbnail.jpg', GETDATE(), GETDATE(), 'Migration', GETDATE(), 'Migration', 1, 0, 1, 3, 'JavaScript Developer', 'Javascript ES6-ES7-ES8', 'Javascript ES6-ES7-ES8', 0, 25)");

            migrationBuilder.Sql(
                "INSERT INTO [ProgrammersBlog].dbo.Articles (Title,[Content],Note,Thumbnail,[Date],[CreatedDate],CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted,UserId,CategoryId,SeoAuthor,SeoDescription,SeoTags,CommentCount,ViewsCount) " +
                "VALUES ('Python ile Veri Analizi','Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. ...', 'İlk Python Paylaşımı', 'postImages/defaultThumbnail.jpg', GETDATE(), GETDATE(), 'Migration', GETDATE(), 'Migration', 1, 0, 1, 4, 'Python Developer', 'Python ile Algoritmalar ve Veri Analizi', 'Python ile Algoritmalar ve Veri Analizi', 0, 99)");

            migrationBuilder.Sql(
                "INSERT INTO [ProgrammersBlog].dbo.Articles (Title,[Content],Note,Thumbnail,[Date],[CreatedDate],CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted,UserId,CategoryId,SeoAuthor,SeoDescription,SeoTags,CommentCount,ViewsCount) " +
                "VALUES ('Java ile Android ve Mobil Programlama','Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. ...', 'İlk Java Paylaşımı', 'postImages/defaultThumbnail.jpg', GETDATE(), GETDATE(), 'Migration', GETDATE(), 'Migration', 1, 0, 1, 5, 'Java Developer', 'Java, Kotlin, Android', 'Java, Kotlin, Android', 0, 235)");

            migrationBuilder.Sql(
                "INSERT INTO [ProgrammersBlog].dbo.Articles (Title,[Content],Note,Thumbnail,[Date],[CreatedDate],CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted,UserId,CategoryId,SeoAuthor,SeoDescription,SeoTags,CommentCount,ViewsCount) " +
                "VALUES ('Dart ve Flutter ile IOS & Android Programlama','Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. ...', 'İlk Java Paylaşımı', 'postImages/defaultThumbnail.jpg', GETDATE(), GETDATE(), 'Migration', GETDATE(), 'Migration', 1, 0, 1, 6, 'Dart Developer', 'Dart, Flutter, Android, IOS, Mobil', 'Dart, Flutter, Android, IOS, Mobil', 0, 666)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
