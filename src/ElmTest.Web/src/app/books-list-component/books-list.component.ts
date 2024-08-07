import { Component, ElementRef, ViewChild } from '@angular/core';
import { BooksApiService } from '../books-api.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrl: './books-list.component.css'
})
export class BooksListComponent {

  public books: any[] = [];
  public totalCount = 0;
  public pageIndex = 0;
  public pageSize = 10;
  

  @ViewChild('uiElement', { static: false }) public uiElement: ElementRef;

  

  constructor(private BooksService: BooksApiService) {

  }

  public async ngOnInit(): Promise<void> {
    await this.getBooks(this.pageIndex, this.pageSize);
    this.pageIndex += 1;
  }

  public async getBooks(pageIndex: number, pageSize: number) {
    try {
      const response: any = await this.BooksService.getBooks(pageIndex, pageSize).toPromise();
      this.books = [...this.books, ...response.data]
      this.totalCount = response.totalCount;
    } catch (error) {
      console.log(error)
    }
  }

  //public async onScrollLoadData() {
  //  if (this.books.length !== this.totalCount) {
  //    await this.getBooks(this.pageIndex, this.pageSize);
  //    this.pageIndex += 1;
  //  }
  //}

  public async onScrollLoadData() {
    const nativeElement = this.uiElement.nativeElement
    if (nativeElement.clientHeight + Math.round(nativeElement.scrollTop) === nativeElement.scrollHeight && this.books.length !== this.totalCount) {
      await this.getBooks(this.pageIndex, this.pageSize);
      this.pageIndex += 1;
    }
  }


}
