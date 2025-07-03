import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CollapseModule } from 'ngx-bootstrap/collapse';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  imports: [CommonModule, CollapseModule],
  standalone: true
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  constructor() { }

  ngOnInit() {
  }

}
