import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rappel',
  templateUrl: './rappelSession.component.html',
  styleUrls: ['./rappelSession.component.css']
})
export class RappelSessionComponent implements OnInit {

  constructor(private service: HttpClient, private router: Router) { }
  poste: string;
  missions: string;
  responsabilite: string;
  dateD: string;
  dateF: string

  ngOnInit() {

    this.service.get(window.location.origin + "/api/Sessions/" + this.router.url.split('/')[2]).subscribe(result => {
      console.log(result)
      this.poste = result['_poste'];
      this.missions = result['_missions'];
      this.responsabilite = result['_responsabilite'];
      this.dateD = result['_dateD'];
      this.dateF = result['_dateF'];
    }, error => console.error(error));
  }
}
