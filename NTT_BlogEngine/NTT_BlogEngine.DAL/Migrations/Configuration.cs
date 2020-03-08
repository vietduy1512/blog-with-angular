namespace NTT_BlogEngine.DAL.Migrations
{
    using NTT_BlogEngine.BlogEngineHelpers;
    using NTT_BlogEngine.DAL.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    

    internal sealed class Configuration : DbMigrationsConfiguration<NTT_BlogEngine.DAL.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "NTT_BlogEngine.DAL.Data.ApplicationDbContext";
        }

        protected override void Seed(NTT_BlogEngine.DAL.Data.ApplicationDbContext context)
        {
            var entityRep = new EntityRepository(context);


            var post = new Post
            {
                Title = "Khoang hành lý trên xe hơi có máy để ở giữa!",
                Slug = RegexHelper.CreateSlug("Khoang hành lý trên xe hơi có máy để ở giữa!"),
                Description = "Xe có máy để ở giữa hai trục có khoang hành lý ở trước và sau trong khi hầu hết xe hơi khác của loài người thì máy ở trước còn khoang hành lý ở sau. Với chiếc xe thể thao 2 chỗ ngồi hai cửa nhỏ như chiếc Porsche 718 Cayman mình giới thiệu trong bài này thì hai khoang hành lý giúp để được...",
                Content = "<h2>Introduction</h2><p>In this article I will demonstrate how you can use Autofac IoC container in MVC application. This article will cover various dependency injection scenarios in MVC, namely: controller, custom filter and view dependency injection.&nbsp;</p><p>In large applications development you will usually have different projects which contains different parts of your architecture like data, services, UI ..etc. Thats why in this article I have created a solution that contains more than one project so it can be as close to real application development as possible. Figure 1 shows the solution structure.</p>",
                ImagePath = "~/Content/img/post-img/SACH_1.jpg",
                Date = DateTime.Now
            };

            var comment = new Comment
            {
                Content = "This is comment for post 1",
                Date = DateTime.Now,
                Post = post
            };

            var post2 = new Post
            {
                Title = "Tìm được bằng chứng cho thấy từng có sự sống trên sao Hỏa",
                Slug = RegexHelper.CreateSlug("Tìm được bằng chứng cho thấy từng có sự sống trên sao Hỏa"),
                Description = "Từ các mẫu vật lấy từ phần đá bùn có niên đại lên đến 3 tỷ năm tuổi ở miệng núi lửa Gale (sao Hỏa), qua phân tích, tàu thăm dò Curiosity...",
                Content = "Từ các mẫu vật lấy từ phần đá bùn có niên đại lên đến 3 tỷ năm tuổi ở miệng núi lửa Gale (sao Hỏa), qua phân tích, tàu thăm dò Curiosity phát hiện thấy có sự tồn tại của chất hữu cơ bên trong chúng. Bên cạnh đó, NASA cũng cho biết Curiosity còn tìm thấy khí metan trong bầu khí quyển của hành tinh Đỏ.<br/>Sự sống của bất kỳ hành tinh nào đều được xây dựng nên từ những nền tảng nhất định và như chúng ta đã biết, chúng bao gồm các hợp chất hữu cơ và phân tử.Tìm thấy hợp chất hữu cơ là dấu hiệu cho hàng loạt các thông tin khác nhau, chẳng hạn như sự tồn tại của một nền văn minh cổ đại, nguồn thức ăn hỗ trợ sự sống hoặc một dạng sống nào đó mà con người chưa từng được biết đến. ",
                ImagePath = "~/Content/img/post-img/SACH_2.jpg",
                Date = DateTime.Now
            };

            var comment2 = new Comment
            {
                Content = "This is comment for post 2",
                Date = DateTime.Now,
                Post = post2
            };

            var post3 = new Post
            {
                Title = "[Infographic] Nguy cơ mắc các bệnh nguy hiểm ở từng độ tuổi và cách phòng ngừa",
                Slug = RegexHelper.CreateSlug("[Infographic] Nguy cơ mắc các bệnh nguy hiểm ở từng độ tuổi và cách phòng ngừa"),
                Description = "Mặc dù tuổi thọ trung bình lớn hơn nhiều so với hai thập niên trước nhưng dân số ngày nay phải đối mặt với nguy cơ mắc các bệnh nguy hiểm ngày càng cao hơn nhất là các bệnh về tim mạch và ung thư.",
                Content = "Mặc dù tuổi thọ trung bình lớn hơn nhiều so với hai thập niên trước nhưng dân số ngày nay phải đối mặt với nguy cơ mắc các bệnh nguy hiểm ngày càng cao hơn nhất là các bệnh về tim mạch và ung thư. Các căn bệnh nguy hiểm này bắt nguồn từ nhiều nguyên nhân tuy nhiên kết quả điều trị phụ thuộc rất nhiều vào việc phòng ngừa và phát hiện sớm. Ở từng độ tuổi khác nhau sẽ có nguy cơ mắc các loại bệnh khác nhau và mức độ nguy hiểm của chúng cũng khác nhau.Để biết rõ hơn, mời các bạn theo dõi infographic sau đây!",
                ImagePath = "~/Content/img/post-img/SACH_3.jpg",
                Date = DateTime.Now
            };

            var comment3 = new Comment
            {
                Content = "This is comment for post 3",
                Date = DateTime.Now,
                Post = post3
            };

            var post4 = new Post
            {
                Title = "Tesla sắp có bản update để xe có thể tự lái hoàn toàn!",
                Slug = RegexHelper.CreateSlug("Tesla sắp có bản update để xe có thể tự lái hoàn toàn!"),
                Description = "Autopilot là tính năng lái xe tự động của Tesla, nhưng hiện tại nó chỉ mới làm được một số thứ mang tính hỗ trợ như tự bẻ bánh lái để bạn chạy đúng làn, tự thắng, tự tăng tốc... và điều kiện là tái xế phải đặt tay lên vô lăng.",
                Content = "Autopilot là tính năng lái xe tự động của Tesla, nhưng hiện tại nó chỉ mới làm được một số thứ mang tính hỗ trợ như tự bẻ bánh lái để bạn chạy đúng làn, tự thắng, tự tăng tốc... và điều kiện là tái xế phải đặt tay lên vô lăng.<br/> Nhưng trong bản update Tesla Version 9.0 sắp tới, Autopilot 2.0 sẽ có khả năng tự lái hoàn toàn. Tất nhiên xe làm được là một chuyện, và luật có cho phép hay không, cho phép như thế nào là một câu chuyện khác. Tesla nói thêm tất cả những gì bạn cần làm là bước vô và nói nơi bạn muốn đến.Nếu bạn không nói gì cả,xe tự chở bạn tới địa điểm trên lịch hẹn của mình,hoặc chở bạn về nhà.Xe sẹ tự tính toán đường tới ưu,tự lái xuyên qua những con đường đô thị(ngay cả khi không phân làn),tự dừng lại khi có đèn đỏ hoặc bảng hiệu bắt buộc dừng,rồi tìm kiếm chỗ đỗ xe",
                ImagePath = "~/Content/img/post-img/SACH_4.jpg",
                Date = DateTime.Now
            };

            var comment4 = new Comment
            {
                Content = "This is comment for post 4",
                Date = DateTime.Now,
                Post = post4
            };


            entityRep.Add<Post>(post);
            entityRep.Add<Comment>(comment);
            entityRep.Add<Post>(post2);
            entityRep.Add<Comment>(comment2);
            entityRep.Add<Post>(post3);
            entityRep.Add<Comment>(comment3);
            entityRep.Add<Post>(post4);
            entityRep.Add<Comment>(comment4);
          
            entityRep.SaveChanges();
        }
    }
}
