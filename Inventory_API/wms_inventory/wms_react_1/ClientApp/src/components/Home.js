//npm install --save @fullcalendar/react @fullcalendar/daygridNPM 
import React, { Component } from 'react';
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
//npm i @fullcalendar/interaction
import interactionPlugin from "@fullcalendar/interaction"; // needed for dayClick
import timeGridPlugin from '@fullcalendar/timegrid'
import { formatDate } from '@fullcalendar/react';


export class Home extends Component {
  static displayName = Home.name;

  render() {
    let str = formatDate(new Date(), {
      month: 'long',
      year: 'numeric',
      day: 'numeric'
    });



    console.log(str);
    return (

      <FullCalendar

        plugins={[dayGridPlugin, interactionPlugin, timeGridPlugin]}
        headerToolbar={
          {
            left: "prev,next today",
            center: "title",
            right: "dayGridMonth,timeGridWeek,timeGridDay,listWeek"
          }}
          
        initialView="dayGridMonth"
        weekends={false}
        events={[
          { title: 'event 1', date: '2020-11-03' },
          { title: 'event 2', date: '2020-11-05' }
        ]}
        // For interaction plugin
        dateClick={this.handleDateClick}

        //Content Injection
        eventContent={renderEventContent}
      />
    );
  }
  handleDateClick = (arg) => { // bind with an arrow function
    alert(arg.dateStr)
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