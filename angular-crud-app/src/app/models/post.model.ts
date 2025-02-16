export interface Post {
    id: number;
    uniqueId:string;
    title:string;
    content:string;
    createdAt:Date;
    author?:string;
    category?:string;
    updatedAt?:Date;
    likesCount:number;
    authorId?:number;
    isPublished:boolean;
    views: number;
  }
  // {
  //   id: number;
  //   uniqueId: string;
  //   title: string;
  //   content: string;
  //   createdAt: Date;
  //   updatedAt?: Date;
  //   author?: string;
  //   category?: string;
  //   isPublished: boolean;
  //   likesCount: number;
  //   views: number;
  // }
  