import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(public router:Router) { }

  ngOnInit(): void {
  }

  logout()
  {
    localStorage.clear();
    alert('Logging Out!');
    this.router.navigateByUrl('');
  }

}
