namespace lib_tz1.models
{
    public class Book_issue
    {
            public int id { get; set; }
            public int book_id { get; set; }
            public Book book { get; set; }
            public int user_id { get; set; }
            public User user { get; set; }
            public DateTime issue_date { get; set; }
            public DateTime return_date { get; set; }

    }
}
