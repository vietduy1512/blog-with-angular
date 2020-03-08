export class Comment {
    Id: Number;
    Content: string;
    Date: Date;
    User: {
      Id: string,
      UserName: string,
      Email: string
    };
    Post: {
      Id: string,
      Title: string,
      Slug: string
    };
  }
