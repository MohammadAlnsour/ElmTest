import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BooksApiService {

  public baseUrl = "http://localhost:4200"
  public headers: HttpHeaders = new HttpHeaders({
    'Content-Type': 'application/json',
    'Accept': "application/json",
    'Access-Control-Allow-Methods': 'GET,POST,PUT,DELETE',
    'Authorization': ''
  });

  constructor(private http: HttpClient) { }

  public getBooks(pageIndex: number, pageSize: number) {
    let params = new HttpParams();
    return this.http.get(`${this.baseUrl}/api/Book?pageNumber=${pageIndex}&pageSize=${pageSize}`, { headers: this.headers, params })
  }


}
