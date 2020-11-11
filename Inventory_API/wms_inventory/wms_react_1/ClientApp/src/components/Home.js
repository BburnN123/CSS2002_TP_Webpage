//npm install --save @fullcalendar/react @fullcalendar/daygridNPM 
import React, { Component } from 'react';
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
//npm i @fullcalendar/interaction
import interactionPlugin from "@fullcalendar/interaction"; // needed for dayClick
import timeGridPlugin from '@fullcalendar/timegrid'
import { formatDate } from '@fullcalendar/react';
import listPlugin from '@fullcalendar/list';

import bootstrapPlugin from '@fullcalendar/bootstrap';
import '@fortawesome/fontawesome-free/css/all.css'; // needs additional webpack config!

export class Home extends Component {
  static displayName = Home.name;

  render() {
    let str = formatDate(new Date(), {
      month: 'long',
      year: 'numeric',
      day: 'numeric'
    });
    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    return (

      <FullCalendar
        plugins={[dayGridPlugin, interactionPlugin, timeGridPlugin, listPlugin, bootstrapPlugin]}

        headerToolbar={
          {
            left: "prev,next today",
            center: "title",
            right: "dayGridMonth,timeGridWeek,timeGridDay,listWeek"
          }}
        // themeSystem='bootstrap'
        initialView="dayGridMonth"
        weekends={false}
        events={[

          {
            title: 'Incoming',
            start: new Date(y, m, d, 12, 0),
            end: new Date(y, m, d, 14, 0),
            allDay: false,
            className: 'fc-primary',
            description: 'Eat Bro'
          },
          {
            title: 'Outgoing',
            start: new Date(y, m, d + 3, 13, 30),
            allDay: false,
            className: 'fc-primary-solid',
            backgroundColor: 'red',
            borderColor: 'red',
            description: 'Meeting'
          },
          {
            title: 'Outgoing',
            start: new Date(y, m, d + 1, 19, 0),
            end: new Date(y, m, d + 1, 22, 30),
            allDay: false,
            className: 'fc-success',
            backgroundColor: 'red',
            borderColor: 'red',
            description: 'Coba Googling dulu'
            
          }
    
        ]
        }
        // For interaction plugin
        dateClick={this.handleDateClick}

        //Content Injection
        // eventContent={renderEventContent}
      />
    );
  }
  handleDateClick = (arg) => { // bind with an arrow function
    // alert(arg.event.extendedProps)
    console.log(arg.dateStr)
  }
}

function renderEventContent(eventInfo) {
  console.log(eventInfo)
  return (
    <>
      <b>{eventInfo.timeText}</b>
      <i>{eventInfo.event.title}</i>
    </>
  )
}

