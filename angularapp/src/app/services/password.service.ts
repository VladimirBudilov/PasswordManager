import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface PasswordEntry {
  isVisible : boolean;
  id: number;
  name: string;
  password: string;
  type: 'site' | 'email';
  date: Date;
}

@Injectable({
  providedIn: 'root'
})
export class PasswordService {
  private apiUrl = 'http://localhost:5000/api/passwords';  // URL для вашего API

  constructor(private http: HttpClient) { }

  getPasswords(): Observable<PasswordEntry[]> {
    return this.http.get<PasswordEntry[]>(this.apiUrl);
  }

  addPassword(entry: PasswordEntry): Observable<PasswordEntry> {
    return this.http.post<PasswordEntry>(this.apiUrl, entry);
  }
}
