import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {map, Observable} from 'rxjs';

export interface PasswordEntry {
  isVisible : boolean;
  name: string;
  password: string;
  type: 'site' | 'email';
  createdAt: Date;
}

@Injectable({
  providedIn: 'root'
})
export class PasswordService {
  private apiUrl = 'http://localhost:8080/api/passwords';

  constructor(private http: HttpClient) { }

  getPasswords(occurrenceInEmail?: string): Observable<PasswordEntry[]> {
    let params = new HttpParams();
    if (occurrenceInEmail) {
      params = params.append('occurrenceInEmail', occurrenceInEmail);
    }

    return this.http.get<{ passwords: PasswordEntry[] }>(this.apiUrl, { params }).pipe(
      map(response => response.passwords)
    );
  }

  addPassword(entry: PasswordEntry): Observable<PasswordEntry> {
    return this.http.post<PasswordEntry>(this.apiUrl, entry);
  }
}
