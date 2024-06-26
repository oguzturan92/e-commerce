using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class DescriptionConfiguration : IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.HasData(
                new Description() {
                    DescriptionId=1,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=1
                },
                new Description() {
                    DescriptionId=2,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=1
                },
                new Description() {
                    DescriptionId=3,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=1
                },
                new Description() {
                    DescriptionId=4,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=2
                },
                new Description() {
                    DescriptionId=5,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=2
                },
                new Description() {
                    DescriptionId=6,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=2
                },
                new Description() {
                    DescriptionId=7,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=3
                },
                new Description() {
                    DescriptionId=8,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=3
                },
                new Description() {
                    DescriptionId=9,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=3
                },
                new Description() {
                    DescriptionId=10,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=4
                },
                new Description() {
                    DescriptionId=11,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=4
                },
                new Description() {
                    DescriptionId=12,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=4
                },
                new Description() {
                    DescriptionId=13,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=5
                },
                new Description() {
                    DescriptionId=14,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=5
                },
                new Description() {
                    DescriptionId=15,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=5
                },
                new Description() {
                    DescriptionId=16,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=6
                },
                new Description() {
                    DescriptionId=17,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=6
                },
                new Description() {
                    DescriptionId=18,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=6
                },
                new Description() {
                    DescriptionId=19,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=7
                },
                new Description() {
                    DescriptionId=20,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=7
                },
                new Description() {
                    DescriptionId=21,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=7
                },
                new Description() {
                    DescriptionId=22,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=8
                },
                new Description() {
                    DescriptionId=23,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=8
                },
                new Description() {
                    DescriptionId=24,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=8
                },
                new Description() {
                    DescriptionId=25,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=9
                },
                new Description() {
                    DescriptionId=26,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=9
                },
                new Description() {
                    DescriptionId=27,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=9
                },
                new Description() {
                    DescriptionId=28,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=10
                },
                new Description() {
                    DescriptionId=29,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=10
                },
                new Description() {
                    DescriptionId=30,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=10
                },
                new Description() {
                    DescriptionId=31,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=11
                },
                new Description() {
                    DescriptionId=32,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=11
                },
                new Description() {
                    DescriptionId=33,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=11
                },
                new Description() {
                    DescriptionId=34,
                    DescriptionName="Açıklama",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!&nbsp; Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=1,
                    ProductId=12
                },
                new Description() {
                    DescriptionId=35,
                    DescriptionName="İade ve Değişim",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat! Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=2,
                    ProductId=12
                },
                new Description() {
                    DescriptionId=36,
                    DescriptionName="Taksit ve Ödeme",
                    DescriptionContent="<p><span style=font-size:12px>Lorem ipsum dolor sit amet consectetur adipisicing elit. Velit iste, odit placeat commodi voluptatem sunt enim! Dolores quasi, amet voluptate suscipit, reiciendis reprehenderit itaque voluptatibus laudantium incidunt ipsa excepturi fugiat!</p>",
                    DescriptionApproval=true,
                    DescriptionSort=3,
                    ProductId=12
                }
            );
        }
    }
}