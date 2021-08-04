import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ColorTheme } from '../../../value-objects/color-theme';

@Injectable({
  providedIn: 'root'
})
export class ColorThemeService {

  private key = "colorTheme";

  private selectedColorTheme = new BehaviorSubject(this.colorTheme);
  
  constructor() { }
  
  set colorTheme(value: ColorTheme) {
    localStorage.setItem(this.key, JSON.stringify(value));
    this.selectedColorTheme.next(value);
  }
 
  get colorTheme(): ColorTheme {
    const json = localStorage.getItem(this.key);
    if (json != undefined) {
      return JSON.parse(json) as ColorTheme;
    }
    else{
      return ColorTheme.white;
    }
  }
}
