import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Session } from '../Model/Session';


@Component({
  selector: 'app-salons',
  templateUrl: './mesSalons.component.html',
  styleUrls: ['./mesSalons.component.css']
})

export class MesSalonsComponent implements OnInit {

  constructor(private service: HttpClient) { }
  private listeSessions: Session[] = [];

  ngOnInit() {
    this.service.get(window.location.origin + "/api/Sessions").subscribe(result => {
	34ec3e036a0f78cefae4350de7276a29dfd2e72c
      this.listeSessions = result as Session[];
      console.log(this.listeSessions);
    }, error => console.error(error));
  }


  MesSalons() {
    document.getElementById("ongletMesSalons").style.cssText = "border-bottom: 5px solid #F28118;";
    document.getElementById("ongletSalonsCrees").style.cssText = "border-bottom: 0px solid #F28118;";
    document.getElementById("ongletSalonsTermines").style.cssText = "border-bottom: 0px solid #F28118;";
  }
  SalonsCrees() {
    document.getElementById("ongletMesSalons").style.cssText = "border-bottom: 0px solid #F28118;";
    document.getElementById("ongletSalonsCrees").style.cssText = "border-bottom: 5px solid #F28118;";
    document.getElementById("ongletSalonsTermines").style.cssText = "border-bottom: 0px solid #F28118;";
  }
  SalonsTermines() {
    document.getElementById("ongletMesSalons").style.cssText = "border-bottom: 0px solid #F28118;";
    document.getElementById("ongletSalonsCrees").style.cssText = "border-bottom: 0px solid #F28118;";
    document.getElementById("ongletSalonsTermines").style.cssText = "border-bottom: 5px solid #F28118;";
  }
  AjouterSalon() {
    console.log("test");
  }
}
