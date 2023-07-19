import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public forecast?: WeatherForecast[];

  constructor(http: HttpClient) {
    http.get<WeatherForecast[]>('api/weatherforecast').subscribe(result => {
      this.forecast = result;
    }, error => console.error(error));
  }

  title = 'angularapp';
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
