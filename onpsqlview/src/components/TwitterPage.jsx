import React, { useEffect, useState } from "react";
import axios from "axios";
import TwitterList from "./TwitterList";

const TwitterPage = () => {
  const [tweets, setTweets] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:80/api/twitter") // Replace with your backend endpoint
      .then((res) => {
        setTweets(res.data);
      })
      .catch((err) => {
        console.error("Failed to fetch tweets:", err);
      });
  }, []);

  return (
    <div>
      <h2>All Tweets</h2>
      <TwitterList tweets={tweets} />
    </div>
  );
};

export default TwitterPage;
