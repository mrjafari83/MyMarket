namespace Application.Services.Common.Comment.Queries.GetAllCommentsByPageId
{
    public class GetAllCommentsByPageIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string ImageSrc { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string CreateDate { get; set; }
        public int VisitingParent { get; set; }
    }
}
