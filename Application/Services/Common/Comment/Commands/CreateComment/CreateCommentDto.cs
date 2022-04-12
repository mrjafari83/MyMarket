namespace Application.Services.Common.Comment.Commands.CreateComment
{
    public class CreateCommentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public string ImageSrc { get; set; }
        public int PageId { get; set; }
        public int ParentId { get; set; }
        public int VisitingParent { get; set; }
    }
}
