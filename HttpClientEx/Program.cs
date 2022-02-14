using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            GetDataAsync().Wait();
            //AddPostAsync().Wait();
            //UpdatePostAsync().Wait();
            //DeletePostAsync().Wait();


        }
        class Post
        {
            public int userId { get; set; }
            public int id { get; set; }

            public string title{get; set;}

            public string body { get; set; }
        
        }
      private static async Task GetDataAsync()
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<Post>>(jsonString);

                Console.WriteLine($"First post title: {posts[0].title}");
                Console.ReadKey();
              
            }

         }
      /*private static async Task AddPostAsync()
        {
            var posts = new Post { userId= 2, 
                                    id = 101,
                                    title = "This is Add Post Title",
                                    body = "This is Add Post Body"};
            HttpClient httpClient = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(posts);
            var content = new StringContent(jsonString);
            var response = await httpClient.PostAsync("https://jsonplaceholder.typicode.com/posts", content);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post Add Sucessfully......");
                Console.ReadKey();
            }
        }*/
     /*private static async Task UpdatePostAsync()
      {
        
            var posts = new Post
            {
                userId = 2,
                id = 100,
                title = "This is Add Update Post Title",
                body = "This is Add Update Post Body"
            };
            HttpClient httpClient = new HttpClient();
            var jsonString = JsonConvert.SerializeObject(posts);
            var content = new StringContent(jsonString);
            var response = await httpClient.PutAsync("https://jsonplaceholder.typicode.com/posts/100", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Updated Post Succesfully......");
                Console.ReadKey();
            }
        }*/

       /* private static async Task DeletePostAsync()
        {

            HttpClient httpClient = new HttpClient();
           
            var response = await httpClient.DeleteAsync("https://jsonplaceholder.typicode.com/posts/100");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Deleted Post Succesfully......");
                Console.ReadKey();
            }
        }*/
    }
}
