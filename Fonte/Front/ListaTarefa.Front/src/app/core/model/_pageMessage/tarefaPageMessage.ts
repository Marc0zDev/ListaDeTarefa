import { Tarefa } from "../tarefa";

export class TarefaPageMessage {
    pageNumber: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
    items: Tarefa[];
  
    constructor(pageNumber: number, pageSize: number, totalCount: number, totalPages: number, hasPrevious: boolean, hasNext: boolean, items: Tarefa[]) {
      this.pageNumber = pageNumber;
      this.pageSize = pageSize;
      this.totalCount = totalCount;
      this.totalPages = totalPages;
      this.hasPrevious = hasPrevious;
      this.hasNext = hasNext;
      this.items = items;
    }
  }