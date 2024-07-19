public interface IVideo
{
    string Title { get; }
    string Author { get; }
    int LengthInSeconds { get; }
    void AddComment(CommentBase comment);
    int GetNumberOfComments();
    IEnumerable<CommentBase> GetAllComments();
}

public abstract class CommentBase
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    protected CommentBase(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public abstract string GetCommentDetails();
}

public class Comment : CommentBase
{
    public Comment(string commenterName, string commentText) 
        : base(commenterName, commentText)
    {
    }

    public override string GetCommentDetails()
    {
        return $"- {CommenterName}: {CommentText}";
    }
}

public class Video : IVideo
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<CommentBase> _comments { get; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        _comments = new List<CommentBase>();
    }

    public void AddComment(CommentBase comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public IEnumerable<CommentBase> GetAllComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<IVideo>();

        var video1 = new Video("How to Play Guitar", "GuitarMaster", 600);
        video1.AddComment(new Comment("Alice", "Great video! Really helpful."));
        video1.AddComment(new Comment("Bob", "Could you also do a tutorial on advanced musical scores?"));
        video1.AddComment(new Comment("Carol", "Nice explanation, thank you!"));

        var video2 = new Video("How to Build a Castle in Minecraft", "TheBigCraft", 1243);
        video2.AddComment(new Comment("Dave", "Very clear and concise."));
        video2.AddComment(new Comment("Eve", "I didn't understand the last part, can you clarify?"));
        video2.AddComment(new Comment("Chris", "That's really cool, now I can surprise my girlfriend, thanks, dude!"));

        var video3 = new Video("The Difference Between Japanese and Chinese", "OrientLanguage", 320);
        video3.AddComment(new Comment("Frank", "Could you do a comparison with other languages?"));
        video3.AddComment(new Comment("Grace", "This helped me a lot with my assignment!"));
        video3.AddComment(new Comment("Victoria", "Thanks, could you make a video about the difference between Korean and Japanese?"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.GetAllComments())
            {
                Console.WriteLine(comment.GetCommentDetails());
            }

            Console.WriteLine();
        }
    }
}
