export class Post {
    Id: Number;
    Title: string;
    Slug: string;
    Description: string;
    ImagePath: string;
    Content: string;
    Date: Date;
    Author: {
      Id: string,
      UserName: string,
      Email: string
    };
  }
