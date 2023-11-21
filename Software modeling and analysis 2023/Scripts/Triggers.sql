CREATE TRIGGER trgAfterUpdateComment ON COMMENT
FOR UPDATE
AS
	declare @commentid int;
	declare @comment varchar(255);
	declare @likes int= 0;

	select @commentid=item.CommentId from inserted item;	
	select @comment=item.Comment from inserted item;	
	
	if UPDATE(Comment)
	BEGIN
		UPDATE COMMENT
		SET Comment = @comment, Likes = @likes
		WHERE CommentId = @commentid;
	END

	PRINT 'AFTER UPDATE Comment Content - Likes set to 0.'
GO

UPDATE COMMENT SET Comment='The comment content is updated' WHERE CommentId=4

