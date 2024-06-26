using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeEntity.Concrete;

namespace ProjeData.Concrete.Configuration
{
    public class Category2Configuration : IEntityTypeConfiguration<Category2>
    {
        public void Configure(EntityTypeBuilder<Category2> builder)
        {
            builder.HasData(
                new Category2() {
                    Category2Id = 1,
                    Category2Name = "Üst Giyim",
                    Category2Description = "",
                    Category2Url = "ust-giyim",
                    Category2Approval = true,
                    Category2Sort = 1,
                    Category2ListType = "Urun",
                    Category2Visibility = "MenuTrue",
                    CategoryId = 1
                },
                new Category2() {
                    Category2Id = 2,
                    Category2Name = "Alt Giyim",
                    Category2Description = "",
                    Category2Url = "alt-giyim",
                    Category2Approval = true,
                    Category2Sort = 2,
                    Category2ListType = "Urun",
                    Category2Visibility = "MenuTrue",
                    CategoryId = 1
                },
                new Category2() {
                    Category2Id = 3,
                    Category2Name = "Dış Giyim",
                    Category2Description = "",
                    Category2Url = "dis-giyim",
                    Category2Approval = true,
                    Category2Sort = 3,
                    Category2ListType = "Urun",
                    Category2Visibility = "MenuTrue",
                    CategoryId = 1
                },

                new Category2() {
                    Category2Id = 4,
                    Category2Name = "Casual",
                    Category2Description = "",
                    Category2Url = "casual",
                    Category2Approval = true,
                    Category2Sort = 1,
                    Category2ListType = "Urun",
                    Category2Visibility = "MenuTrue",
                    CategoryId = 2
                },
                new Category2() {
                    Category2Id = 5,
                    Category2Name = "Bot",
                    Category2Description = "",
                    Category2Url = "bot",
                    Category2Approval = true,
                    Category2Sort = 2,
                    Category2ListType = "Urun",
                    Category2Visibility = "MenuTrue",
                    CategoryId = 2
                },
                new Category2() {
                    Category2Id = 6,
                    Category2Name = "Klasik",
                    Category2Description = "",
                    Category2Url = "klasik",
                    Category2Approval = false,
                    Category2Sort = 3,
                    Category2ListType = "Urun",
                    Category2Visibility = "MenuTrue",
                    CategoryId = 2
                },

                new Category2() {
                    Category2Id = 7,
                    Category2Name = "Üyelere Özel Kampanyalar",
                    Category2Description = "<p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p><p>&nbsp;</p><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p><p>&nbsp;</p><p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.</p>",
                    Category2Url = "uyelere-ozel-kampanyalar",
                    Category2Approval = true,
                    Category2Sort = 1,
                    Category2ListType = "Icerik",
                    Category2Visibility = "MenuFalse",
                    CategoryId = 4
                },
                new Category2() {
                    Category2Id = 8,
                    Category2Name = "Yüksek Tutar Kampanyaları",
                    Category2Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet dolor officia, dolorum nihil quaerat delectus tempore quibusdam perspiciatis sint, molestiae hic mollitia vero in autem veritatis inventore provident numquam? Aliquid molestiae, est ratione error, facilis officia quis nulla reiciendis beatae necessitatibus placeat maxime, tempora animi adipisci. Eveniet repudiandae incidunt soluta sit iusto porro blanditiis nisi perferendis ex. Ullam, cumque accusantium esse similique ipsa a praesentium illo perferendis saepe optio deleniti sunt ut fuga nihil error aliquam dolor vero quo inventore. Iure, esse ex nesciunt nostrum quis illum excepturi ad inventore est eius tempore ipsam beatae quisquam, asperiores fugiat ullam reiciendis. Assumenda, nihil esse. Aut, architecto mollitia iste natus dicta minima, non consequatur aliquam maiores temporibus ratione reiciendis dignissimos magnam! Doloribus praesentium dolorum odio aliquam? Adipisci obcaecati cupiditate officia at beatae quisquam illum nemo alias tenetur quis recusandae unde, corporis quas necessitatibus nobis natus sed culpa possimus dolore? Nihil commodi veritatis aut eos laborum repudiandae, repellendus nisi! Temporibus corporis veniam, ullam et consequuntur minus suscipit vero error tempore veritatis ipsa saepe sunt necessitatibus repudiandae aspernatur in recusandae ab hic iure beatae voluptas molestias, quaerat aliquam. Cumque a dignissimos harum ullam, distinctio quidem ipsam aperiam nulla maiores vitae quas temporibus velit mollitia.",
                    Category2Url = "yuksek-tutar-kampanyalari",
                    Category2Approval = true,
                    Category2Sort = 2,
                    Category2ListType = "Icerik",
                    Category2Visibility = "MenuFalse",
                    CategoryId = 4
                }
            );
        }
    }
}