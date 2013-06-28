library(ggplot2)
library(plyr)

results = read.csv('results2.txt', header=FALSE)
results = rename(results, c("V1"="Algorithm", "V2"="Time"))
mean_results <- aggregate(Time~Algorithm, data=results, FUN="mean")
png("results2.png")
mean_results
ggplot(data=mean_results, aes(x=Algorithm, y=Time, fill=Algorithm)) + 
geom_bar(stat="identity", ymin=0) + 
ggtitle("Source: Bible, Pattern: 'Jesus'") +
xlab("Time (milliseconds)") +
geom_text(aes(label=Time), vjust=3)
coord_flip()
dev.off()
