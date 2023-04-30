import React from "react";
import './about.css'
import avatar from '../../assests/avatar.png';



const About = () => {
  const members = [
    {
      index: '1',
      name: 'Micheal Soliman',
      role: 'Front-End Developer',
      github: 'https://github.com/Micheal-Soliman'
    },
    {
      index: '2',
      name: 'Mohammad Badee',
      role: 'Back-End Developer',
      github: 'https://github.com/Badea741'
    },
    {
      index: '3',
      name: 'Mohammad Dawoud',
      role: 'Back-End Developer',
      github: 'https://github.com/dawoud007'
    },
  ]

  return (
    <>
      <div className='about'>
        <h1>Our Teams</h1>
        <div className="members">
          {members.map((member) => {
            return (
              <div class="flip-card" onClick={() => window.location.replace(member.github)} title={`Click On Card To Know More About ${member.name}`}>
                <div class="flip-card-inner">
                  <div class="flip-card-front">
                    <img src={avatar} alt="avatar" />
                  </div>
                  <div class="flip-card-back">
                    <h3 >{member.name}</h3>
                    <h3>{member.role}</h3>
                  </div>
                </div>
              </div>
            )
          })}
        </div>
      </div>
    </>
  );
};

export default About;
