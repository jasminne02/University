CREATE PROCEDURE getAllUserUsernames
AS
SELECT Username FROM USERPROFILE
GO;

EXEC getAllUserUsernames;



CREATE PROCEDURE updateContentLikes @ContentId INT
AS
BEGIN
UPDATE CONTENT
SET Likes = Likes + 1
WHERE ContentId = @ContentId
END;

EXEC updateContentLikes @ContentId = 1;


CREATE PROCEDURE updateStoryViews @StoryId INT
AS
BEGIN
UPDATE STORY
SET ViewsCount += 1
WHERE StoryId = @StoryId
END;

EXEC updateStoryViews @StoryId = 2;
EXEC updateStoryViews @StoryId = 3;



CREATE PROCEDURE updateStoryLikes @StoryId INT
AS
BEGIN
UPDATE STORY
SET Likes += 1
WHERE StoryId = @StoryId
END;

EXEC updateStoryLikes @StoryId = 3;



CREATE PROCEDURE updateCommentLikes @CommentId INT
AS
BEGIN
UPDATE COMMENT
SET Likes += 1
WHERE CommentId = @CommentId
END;

EXEC updateCommentLikes @CommentId = 3;
EXEC updateCommentLikes @CommentId = 4;
