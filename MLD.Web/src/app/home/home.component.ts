import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OverlayContainer } from '@angular/cdk/overlay';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  darkTheme = false;

  constructor(private router: Router, private oc: OverlayContainer) {}

  ngOnInit() {}
}
