import { Component, OnInit } from '@angular/core';
import { PasswordService, PasswordEntry } from '../../services/password.service';
import { PasswordModalComponent} from "../password-modal/password-modal.component";

@Component({
  selector: 'app-root',
  templateUrl: './password-list.component.html',
  styleUrls: ['./password-list.component.css']

})
export class PasswordListComponent implements OnInit {
  passwords: PasswordEntry[] = [];
  searchTerm: string = '';

  constructor(private passwordService: PasswordService) { }

  ngOnInit(): void {
    this.loadPasswords();
  }

  loadPasswords(): void {
    this.passwordService.getPasswords().subscribe(passwords => {
      this.passwords = passwords.sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime());
    });
  }

  toggleVisibility(entry: PasswordEntry): void {
    entry.isVisible = !entry.isVisible;
  }

  get filteredPasswords(): PasswordEntry[] {
    return this.passwords.filter(entry =>
      entry.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  openModal() {
  }
}
