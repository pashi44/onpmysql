import React from "react";

const TwitterList = ({ tweets }) => {
  return (
    <div className="twitter-list">
      <h1>Twitter Records</h1>
      <table className="table bg-cream">
        <thead>
          <tr>
            <th>ID</th>
            <th>Country</th>
            <th>Text</th>
            <th>Entities</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {tweets.map((item) => (
            <tr key={item.C0}>
              <td>{item.C0}</td>
              <td>{item.Country || "India"}</td>
              <td>{item.Text}</td>
              <td>{item.User}</td>
              <td>
                <a href={`/details/${item.C0}`}>Details</a>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default TwitterList;