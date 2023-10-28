namespace http_GET
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            List<string> ccTLDs = Init_ccTLD();


            //var client = new HttpClient();
            //var responce = await client.GetByteArrayAsync("https://lms.teachmeskills.com/courses/792/32670/lessonDescription/private-production-bucket/media/materials/lesson-recording/group-NET13-onl/lesson-%D0%A0%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%20%D1%81%20%D0%B8%D0%BD%D1%82%D0%B5%D1%80%D0%BD%D0%B5%D1%82%D0%BE%D0%BC%20%D0%B8%20%D1%81%D0%B5%D1%82%D1%8C%D1%8E/lesson_recording.mp4");
            //List<byte> video = new List<byte>(responce);

            //File.WriteAllBytesAsync($"../../../ccTLDs/1.mp4", video.ToArray());
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://ru.wikipedia.org/wiki/")
            };
            foreach (string ccTLDItem in ccTLDs)
            {
                var response = await client.GetAsync($"{client.BaseAddress + ccTLDItem}");

                try
                {
                    response.EnsureSuccessStatusCode();
                    var textPlain = await response.Content.ReadAsStringAsync();
                    File.WriteAllText($"../../../ccTLDs/{ccTLDItem}.html", textPlain);
                }
                catch (Exception ex)
                {
                    File.AppendAllTextAsync($"../../../ccTLDs/errors.txt", $"No such top-level-domain {ccTLDItem}\n");
                }
                finally
                {
                    response.Dispose();
                }
            }

        }

        public static List<string> Init_ccTLD()
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVQXYZ".ToLowerInvariant().ToCharArray();

            List<string> result = new List<string>();
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    result.Add("." + chars[i] + chars[j]);
                }
            }

            return result;
        }
    }
}